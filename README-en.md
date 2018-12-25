# Crypto
Encapsulate multiple CTFs and common encryption and encoding C# libraries

In my blog, I've written about the introduction and analysis of various types of encryption and functions in the class library.[标签: Crypto | 时光](https://willv.cn/tags/Crypto/)

[中文](https://github.com/WWILLV/Crypto/blob/master/README.md)

## Supported encoding and encryption

### DecryptEncrypt
- Salt (randomly generated)
- 32/16-bit MD5
- XOR(Optional return value is Base64)
- Caesar encryption
- Rot13
- Bacon password
- Fence password
- Virginia password
- AES(128-bit ECB、CBC)
- Sha1、Sha256

### code
- Base64/32
- Morse(Only supports alphanumeric now)(Code)
- url
- ASCII,Unicode and string convert to each other

### Conversion
- Arbitrary conversion(Supports up to 62 binary conversions,does not support decimals now)(Conversion)

### CryptoFileInfo
- Get file md5
- Get file Sha1
- Get file Sha256
- （FileInfo）Get file name, extension, size, creation time last access and write time, attribute

### Cryptofile
- Reverse file to new file
- File to byte array or string
- Byte array or string written to file
- Temporary file operation(CryptoFileInfo support)

### CryptoString
- Generate a random string
- Reverse string
- String, byte array and  stream convert to each other
- Regular match returns an array of results
- Commonly used strings, regular expressions


## Todo
- RSA
- CRC32
- Manchester code
- Differential Manchester code
- Complement code,Inverse code
- Blowfish
- Elliptic Curve Cryptography(ECC)
- DES
- rc4
- brainfuck
- jsfuck https://github.com/aemkei/jsfuck (https://github.com/dNetGuru/JSUNFuck)
- aaencode
- Base16(Code)
- Compressed file pseudo encryption(Including normal encryption and decryption(Need other libraries))
- Tencent TEA algorithm[根据腾讯公开的JS文件分析QQTEA算法](http://blog.csdn.net/gsls200808/article/details/70837455)
- wordpress user's password encryption[wordpress用户密码加密原理及其算法分析](https://blog.csdn.net/HK_JH/article/details/27368279)
- php serialization and deserialization
- baze64（https://github.com/xanderma/QQ-Confess/blob/master/src/Baze64.java）
- gzip,utf8, etc. conversion
- [Detect encryption type]

Virginia Key Crack http://www.practicalcryptography.com/cryptanalysis/stochastic-searching/cryptanalysis-vigenere-cipher/ 

## about
[My Blog](https://willv.cn)


## LICENSE
Apache