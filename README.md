# Mufunge

Mufunge - toolkit for funge family languages: Befunge-93, Funge-98, Unefunge, Trefunge; name inspired by one of the greatest music band ever - [Zvuki Mu](https://www.youtube.com/watch?v=t_0aXsWPltk)  

Toolkit contains interpreters, console and GUI debuggers (debuggers not yet done).

# Compability level

Mufunge has **full** compablity with last [Funge Standard](https://catseye.tc/view/funge-98/doc/funge98.markdown)  

# Supported Versions

Mufunge now can works with Befunge-93, Funge-98, Unefunge, Trefunge versions. You're welcome to implements more dimensions versions via pull request =)

# Tested

Mufunge passed all tests of [Mycology project](https://github.com/Deewiant/Mycology), some tests files placed in *funge-console/examples* directory

# Fingerprints Support

Mufunge now supports only NULL fingerprint, supporting of [all standard fingerprints](http://rcfunge98.com/rcsfingers.html) planned.


# Usage

mufunge program_file [opt1] [opt2] ...
### Options
-h,--h, -help, --help  **display help**

--ignore-ext  **forces Mufunge to execute funge code from file with any extension (by default standard only extension allowed**

--unefunge, --befunge93, --funge98, --trefunge  **runs code in chosen standard (--funge98 default)**

