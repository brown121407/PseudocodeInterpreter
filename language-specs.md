# Language specification

## Keywords
***number***, ***text***, ***if***, ***then***, ***else***, ***else if***, ***until***, ***while***, ***times***, ***do***, ***end***, ***function***, ***return***

## Types:
- numbers
    ```ruby
    # declaration
    number a

    # initialization
    number a = 3        # integer
    number b = 3.1415   # real
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
    
## Comments
```ruby
number num = 3
# anything after "#" is a comment
# comments are ignored
# num = 15
# the line above will not be executed

num = 16 # now num is equal to 16
```
    
## Numeric operations
- Addition
    ```ruby
    number a = 1 + 1   # a == 2
    ```
- Subtraction
    ```ruby
    number b = 2 - 1   # b == 1
    ```
- Multiplication
    ```ruby
    number c = 3 * 4   # c == 12
    ```
- Division
    ```ruby
    number d = 10 / 2  # d == 5
    number e = 11 / 2     # e == 5.5
    ```
- Integer division
    ```ruby
    number f = 11 // 2 # f == 5
    ```
- Power
    ```ruby
    number g = 2 ** 5  # g == 32
    ```
    
## Boolean operators

- Less than: <
    ```ruby
    1 < 2   # true
    100 < 4 # false
    ```
- Less than or equal to: <=
    ```ruby
    1 <= 1      # true
    31 <= 30    # false
    ```
- Equal to: ==
    ```ruby
    5 == 5  # true
    4 == 6  # false
    ```
- Greater than or equal to: >=
    ```ruby
    4 >= 4  # true
    4 >= 20 # false
    ```
- Greater than: >
    ```ruby
    7 > 4   # true
    7 > 21  # false
    ```

## Built-in functions

- Input/Output
    ```ruby
    # read(arg1, arg2, ...)
    # ---------------------
    # Ask for input from the console and try to fit it into the given parameters
    # Usage:
    number num
    text message
    read(num, message)


    # write(arg1, arg2, ...)
    # ----------------------
    # Write the parameters to the console
    # Usage:
    number num = 43
    text message = "num is equal to "
    write(message, num) # Outputs "num is equal to 43"


    # writeLine(arg1, arg2, ...)
    # --------------------------
    # Write the parameters followed by a new line character to the console
    # Usage:
    text firstLine = "first"
    text secondLine "second"
    writeLine(firstLine)
    writeLine(secondLine) # This will output the strings on separate lines
    ```
- General
    ```ruby    
    # value.toText -> text
    # --------------------
    # Converts the parameter's value to text
    # Works on every basic data type 
    # Usage:
    number num = 54321
    text str = num.toText # str is equal to "54321"


    # array.size -> number
    # ---------------------
    # Returns the number of elemets in an array
    # Usage:
    number arr[20]
    number size = arr.length # size is equal to 20
    ```

## Functions
```ruby
# Declaration
# Function that returns the sum of 2 integers
function sum(number num1, number num2) -> number
    return num1 + num2
end

# Function that prints a message (does not return anything)
function printMessage(text message)
    writeLine(message)
end

# The next line outputs to the console "3"
printMessage(sum(1 + 2).toText)
```
