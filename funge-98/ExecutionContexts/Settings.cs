using funge_98.Enums;

namespace funge_98.ExecutionContexts
{
    public class CustomSettings
    {
        private OptionStatus _isConcurrent;
        private OptionStatus _isSystemCallSupported;
        private OptionStatus _isInputFileSupported;
        private OptionStatus _isOutputFileSupported;
        private OptionStatus _warnIfCommandNotSupported;

        public OptionStatus IsConcurrent
        {
            get => _isConcurrent;
            set
            {
                if (IsConcurrent == OptionStatus.NotSupported)
                    return;
                _isConcurrent = value;
            }
        }

        public OptionStatus IsSystemCallSupported
        {
            get => _isSystemCallSupported;
            set
            {
                if (IsSystemCallSupported == OptionStatus.NotSupported)
                    return;
                _isSystemCallSupported = value;
            }
        }

        public OptionStatus IsInputFileSupported
        {
            get => _isInputFileSupported;
            set
            {
                if (_isInputFileSupported == OptionStatus.NotSupported)
                    return;
                _isInputFileSupported = value;
            }
        }

        public OptionStatus IsOutputFileSupported
        {
            get => _isOutputFileSupported;
            set
            {
                if (_isOutputFileSupported == OptionStatus.NotSupported)
                    return;
                _isOutputFileSupported = value;
            }
        }

        public OptionStatus WarnIfCommandNotSupported
        {
            get => _warnIfCommandNotSupported;
            set
            {
                if (_warnIfCommandNotSupported == OptionStatus.NotSupported)
                    return;
                _warnIfCommandNotSupported = value;
            }
        }
        public UnimplementedPolicy UnimplementedPolicy { get; set; }
    }
}