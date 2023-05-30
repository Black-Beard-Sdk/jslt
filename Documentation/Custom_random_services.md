## Return an integer
### Arguments
- minimum : specify the minimum value
- exclusiveMinimum : specify if the minimum value is include
- maximum : specify the maximum value
- exclusiveMaximum : specify if the maximum value is include
```JSON
{ "result" : getrandom_integer(minimum, exclusiveMinimum, maximum, exclusiveMaximum) }
```

## Return an integer
### Arguments
- minimum : specify the minimum value
- exclusiveMinimum : specify if the minimum value is include
- maximum : specify the maximum value
- exclusiveMaximum : specify if the maximum value is include
```JSON
{ "result" : getrandom_byte(minimum, exclusiveMinimum, maximum, exclusiveMaximum) }

```

## Return a randomized double number
### Arguments
- minimum : specify the minimum value
- exclusiveMinimum" : specify if the minimum value is include
- maximum : specify the maximum value
- exclusiveMaximum" : specify if the maximum value is include
```JSON
{ "result" : getrandom_double(minimum, exclusiveMinimum, maximum, exclusiveMaximum) }
```
   
## Return a randomized float number
### Arguments
- minimum : specify the minimum value
- exclusiveMinimum" : specify if the minimum value is include
- maximum : specify the maximum value
- exclusiveMaximum" : specify if the maximum value is include
```JSON
{ "result" : getrandom_float(minimum, exclusiveMinimum, maximum, exclusiveMaximum) }
```        

## Return a randomized long number
### Arguments
- minimum : specify the minimum value
- exclusiveMinimum" : specify if the minimum value is include
- maximum : specify the maximum value
- exclusiveMaximum" : specify if the maximum value is include
```JSON     
{ "result" : getrandom_long(minimum, exclusiveMinimum, maximum, exclusiveMaximum) }
```

## Return a randomized short number
### Arguments
- minimum : specify the minimum value
- exclusiveMinimum" : specify if the minimum value is include
- maximum : specify the maximum value
- exclusiveMaximum" : specify if the maximum value is include
```JSON
{ "result" : getrandom_short(minimum, exclusiveMinimum, maximum, exclusiveMaximum) }
```

## Return a randomized string
### Arguments
- minimum : specify the minimum value
- exclusiveMinimum" : specify if the minimum value is include
- maximum : specify the maximum value
- exclusiveMaximum" : specify if the maximum value is include
```JSON
{ "result" : getrandom_string(minimum, exclusiveMinimum, maximum, exclusiveMaximum) }
```
        
## Return a randomized datetime
```JSON
{ "result" : getrandom_datatime() }
```

## Return a randomized timespan
```JSON
{ "result" : getrandom_timespan() }
```

## Return a randomized email
```JSON
{ "result" : getrandom_email() }
```

## Return a randomized ip v4
```JSON
{ "result" : getrandom_ipv4() }
```

## Return a randomized ip v6
```JSON
{ "result" : getrandom_ipv6() }
```

## Return a randomized binary
### Arguments
- minlength : specify the minimum value length
- maxlength : specify the maximum value length
```JSON
{ "result" : getrandom_binary(minlength, maxlength) }

```

## Return a randomized boolean
```JSON
{ "result" : getrandom_boolean() }
```

## Return a randomized city
```JSON
{ "result" : getrandom_city()
```        

## Return a randomized country
```JSON
{ "result" : getrandom_country()
```

## Return a randomized lastname
```JSON
{ "result" : getrandom_lastname()
```        

## Return a randomized first name
```JSON
{ "result" : getrandom_firstname()
```

## Return a randomized fullname
```JSON
{ "result" : getrandom_fullname()
```

## Return a randomized iban
### Arguments
- countryCodeIso2 : country code Iso 2
- includeIban : include Iban
- includeBban : include bban
```JSON
{ "result" : getrandom_iban()

```        

## Return a randomized mac address
### Arguments
- minimum : specify the minimum value
- maximum : specify the maximum value
```JSON
{ "result" : getrandom_macaddress()
```

## Return a randomized lipsum text
### Arguments
- paragraphs : specify the count of paragraph
```JSON
{ "result" : getrandom_lipsum()
```        

## Return a randomized naughty string
```JSON
{ "result" : getrandom_naughtystrings()
```        

## Return a randomized password
```JSON     
{ "result" : getrandom_password()
```        