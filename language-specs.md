# Language specification

## Keywords
***integer***, ***real***, ***text***, ***if***, ***then***, ***else***, ***else if***, ***until***, ***while***, ***times***, ***do***, ***end***, ***function***, ***return***

## Types:
- integers
    ```ruby
    # declaration
    integer a

    # initialization
    integer a = 3
    ```
- floats
    ```ruby
    # declaration
    real number

    # initialization
    real number = 3.14
    ```
- text
    ```ruby
    # declaration
    text str

    # initialization
    text str = "content"
    ```
- arrays
    ```ruby
    # declaration
    integer arrayName[10]

    # initialization
    real arrayName[2] = {4.5, 5.4}

    # accessing values (array indexes start with 0)
    text arrayName[3] = {"Hello, ", "World", "!"}
    write(arrayName[0]) # Outputs "Hello, "
    write(arrayName[1]) # Outputs "World"
    write(arrayName[2]) # Outputs "!"
    ```

## Control flow statements
- if 
    ```ruby
    if <condition> then
        ...
    end
    ```
- else
    ```ruby
    if <condition> then
        ...
    else
        ...
    end
    ```
- else if
    ```ruby
    if <condition> then
        ...
    else if <condition> then
        ...
    end
    ```
- while
    ```ruby
    while <condition> do
        ...
    end
    ```
- until
    ```ruby
    until <condition> do
        ...
    end
    ```
- times
    ```ruby
    <intValue> times do
        ...
    end
    ```

## Built-in functions

- Input/Output
    ```ruby
    # Ask for input from the console and try to fit it into the
    # given parameters
    read(arg1, arg2, ...)

    # Write the parameters to the console
    write(arg1, arg2, ...)

    # Write the parameters followed by a new line character to the console
    writeLine(arg1, arg2, ...)
    ```
- General
    ```ruby
    # Converts the parameter's value to text
    # Works on every basic data type 
    toText(integer arg)
    toText(real arg)
    toText(text arg)

    # Returns the number of elemets in an array
    arraySize(integer arrayName[])
    arraySize(real arrayName[])
    arraySize(text arrayName[])
    ```

## Functions
```ruby
# Declaration
# Function that returns the sum of 2 integers
function sum(integer num1, integer num2) -> integer
    return num1 + num2
end

# Function that prints a message (does not return anything)
function printMessage(text message)
    writeln(message)
end

# The next line outputs to the console "3"
printMessage(toText(sum(1 + 2)))
```