# PseudocodeInterpreter

This is an interpreter for a programming language created to resemble pseudocode. Started as a project to execute the pseudocode used in Romanian schools, and scaled to a better form with multiple spoken languages variants.

# Getting started

These instructions will get you a copy of the project up and running on your local machine for common usage. Check [development](#development) for instructions on how to set up for development and testing.

## Prerequisites

- .NET Core 2.1 runtime - download from https://www.microsoft.com/net/download

## Download

Download the [latest binary release](). The program doesn't need to install, just unzip the archive.

## Usage

Write code in your desired language. Note that available languages can be found in [PseudocodeInterpreter/Config/languages.json](PseudocodeInterpreter/Config/languages.json).  
Hello world in english:
```ruby
write("Hello world")
```
To execute the file run:
`PseudocodeInterpreter.exe --file="/path/to/file"` 

The default language is English. To use another language, for example Romanian, use the `lang` flag:
```ruby
scrie("Hello world")
```
`PseudocodeInterpreter.exe --file="path/to/file" --lang="ro"`

To display help use:  
`PseudocodeInterpreter.exe --help`

# Contributing

If you want to contribute to the project you can create an Issue describing a bug/feature or fork the repo and open a Pull Request. All help is appreciated.

# Built with
- [CommandLineParser](https://github.com/commandlineparser/commandline) for CLI arguments parsing
- [Newtonsoft.JSON](https://github.com/JamesNK/Newtonsoft.Json) for reading the config file for languages

# License

 This project is licensed under the GNU General Public License v3.0 - see the [LICENSE](LICENSE) file for details