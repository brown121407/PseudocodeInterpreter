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
    varName.toText -> text

    # Usage
    integer num = 54321
    text str = num.toText # str is equal to "54321"

    # Returns the number of elemets in an array
    arrayName.length -> integer

    # Usage
    integer arr[20]
    integer size = arr.length # size is equal to 20
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
    writeLine(message)
end

# The next line outputs to the console "3"
printMessage(sum(1 + 2).toText)
```