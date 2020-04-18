using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Attributes;
using JetBrains.Annotations;

namespace Container
{
    public class Container
    {
        private readonly List<string> _modules;
        [NotNull]private readonly HashSet<Type> _foundedByResolving = new HashSet<Type>();
        [NotNull]private readonly Dictionary<Type, object> _alreadyCreated = new Dictionary<Type, object>();
        private List<Type> _markedTypes;

        public Container([NotNull]List<string> modules)
        {
            _modules = modules;
        }

        public T Resolve<T>()
        {
            var type = typeof(T);
            if (_alreadyCreated.TryGetValue(type, out var obj))
                return (T) obj;
            obj = ConstructByType(type);
            return (T) obj;
        }

        private object ConstructByType([NotNull] Type t)
        {
            if (_alreadyCreated.TryGetValue(t, out var o))
                return o;

            if (_markedTypes == null)
            {
                var types = Enumerable.Empty<Type>();
                Debug.Assert(_modules != null, nameof(_modules) + " != null");
                
                types = _modules.Select(Assembly.Load).Aggregate(types, (current, logicAssembly) =>
                {
                    if (logicAssembly != null)
                        return (current ?? throw new ArgumentNullException(nameof(current))).Concat(
                            from type in logicAssembly.GetTypes()
                            where Attribute.IsDefined(type, typeof(ContainerElement))
                            select type);
                    return null;
                });
                Debug.Assert(types != null, nameof(types) + " != null");
                _markedTypes = (types).ToList();
            }

            var ctor = GetConstructor(t);
            Debug.Assert(ctor != null, nameof(ctor) + " != null");
            var ctorParams = ctor.GetParameters();
            _foundedByResolving.Add(t);
            ResolvingDependencies(ctorParams.ToList());
            _foundedByResolving.Clear();

            // or select where Select.ctorParams=>param.ParameterType,contains(object key?);
            var parameters = from objects in _alreadyCreated
                join param in ctorParams on objects.Key equals param.ParameterType
                select objects.Value;
            var obj = ctor.Invoke(parameters.ToArray());
            _alreadyCreated[t] = obj;
            return obj;
        }

        private void ResolvingDependencies([NotNull] List<ParameterInfo> dependencies)
        {
            dependencies.ForEach(dependency =>
            {
                Debug.Assert(dependency != null, nameof(dependency) + " != null");
                if (_foundedByResolving.Contains(dependency.ParameterType))
                {
                    _foundedByResolving.Clear();
                    throw new ArgumentException("Found circular dependency");
                }

                if (dependency.ParameterType.IsGenericType &&
                    dependency.ParameterType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    ConstructGenericList(dependency.ParameterType);
                }
                else
                {
                    ConstructByType(dependency.ParameterType);
                }
            });
        }

        private void ConstructGenericList([NotNull]Type genericType)
        {
            var instance = (IList) Activator.CreateInstance(genericType);
            Debug.Assert(instance != null, nameof(instance) + " != null");
            Debug.Assert(genericType.GenericTypeArguments != null, "genericType.GenericTypeArguments != null");
            var parentType = genericType.GenericTypeArguments[0];
            var childrenTypes = (from type in _markedTypes
                where type.GetInterfaces().Contains(parentType)
                select type).ToList();

            childrenTypes.ForEach(childType =>
            {
                if (_alreadyCreated.TryGetValue(childType ?? throw new ArgumentNullException(nameof(childType)), out var child))
                {
                    instance.Add(child);
                }
                else
                {
                    var obj = ConstructByType(childType);
                    instance.Add(obj);
                    _alreadyCreated[childType] = obj;
                }
            });
            _alreadyCreated[genericType] = instance;
        }

        private ConstructorInfo GetConstructor([NotNull] Type type)
        {
            Debug.Assert(_markedTypes != null, nameof(_markedTypes) + " != null");
            if (!_markedTypes.Contains(type))
                throw new ArgumentException($"Type {type} hasn't marked by {typeof(ContainerElement)} attribute");
            var ctors = type.GetConstructors();
            if (ctors.Length == 0)
                throw new ArgumentException($"Type {type} hasn't public constructors!");
            if (ctors.Length > 1)
                throw new ArgumentException($"Type {type} has more than pne public constructors!");
            return ctors[0];
        }
    }
}