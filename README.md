# MAP.AspNetCore.Security


## General information

With this package you can **encrypt** and **decrypt** your usernames, passwords and any Important data.


## How work it

- Encrypt by TRIPLE DES
- Encrypt by ASCIIEncoding

## Usage

#### Add namespace
~~~
MAP.AspNetCore.Security;
~~~

#### Choose one of Encrypt Algorithm from SecurityEncryption

- `Your_String` is string you want to Encrypt
```
SecurityEncryption.SimpleEncrypt(Your_String)
```

- `Your_Encrypt` is string was Encrypted by **`SimpleEncrypt`**
~~~
 SecurityEncryption.SimpleDecrypt(Your_Encrypt)
~~~

- `Your_String` is string you want to Encrypt
- `Your_Key` is string pattern key you want
~~~
 SecurityEncryption.Encrypt3DES(Your_String, Your_Key)
~~~

- `Your_Encrypt` is string was Encrypted by **`Encrypt3DES`**
- `Your_Key` is string pattern key you use in **`Encrypt3DES`**
~~~
 SecurityEncryption.Decrypt3DES(Your_Encrypt, Your_Key)
~~~

### Contact me : 
**If there is a issuse or question, I will be happy to share it with me**
**[https://github.com/Mohammad-Abbasi2559](https://github.com/Mohammad-Abbasi2559)**
