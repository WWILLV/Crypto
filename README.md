# Crypto
Encapsulate multiple CTFs and common encryption and encoding C# libraries

In my blog, I've written about the introduction and analysis of various types of encryption and functions in the class library.[标签: Crypto | 时光](https://willv.cn/tags/Crypto/)

[中文README](https://github.com/WWILLV/Crypto/blob/master/README.md)

## Supported encoding and encryption
- 32/16-bit MD5(DecryptEncrypt)
- Base64/32(Code)
- XOR(Optional return value is Base64)(DecryptEncrypt)
- Caesar encryption(DecryptEncrypt)
- Rot13(DecryptEncrypt)
- Morse(Only supports alphanumeric now)(Code)
- AES(128-bit ECB、CBC)(DecryptEncrypt)
- Bacon password(DecryptEncrypt)
- Fence password(DecryptEncrypt)
- Virginia password(DecryptEncrypt)
- Arbitrary conversion(Supports up to 62 binary conversions,does not support decimals now)(Conversion)
- url(Code)
- ASCII,Unicode and string convert to each other(Code)

## Todo
- RSA(DecryptEncrypt)
- Elliptic Curve Cryptography(ECC)(DecryptEncrypt)
- Sha1、Sha256(DecryptEncrypt)
- DES(DecryptEncrypt)
- rc4(DecryptEncrypt)
- brainfuck
- jsfuck
- Base16(Code)
- Compressed file pseudo encryption(Including normal encryption and decryption(Need other libraries))
- Tencent TEA algorithm[根据腾讯公开的JS文件分析QQTEA算法](http://blog.csdn.net/gsls200808/article/details/70837455)

## about
[My Blog](https://willv.cn)

[About this project](https://willv.cn/projects/Crypto)

## LICENSE
Apache