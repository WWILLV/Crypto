# Crypto
Encapsulate multiple CTFs and common encryption and encoding C# libraries

In my blog, I've written about the introduction and analysis of various types of encryption and functions in the class library.[标签: Crypto | 时光](https://willv.cn/tags/Crypto/)

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
- CRC32
- Manchester code
- Differential Manchester code
- Complement code,Inverse code
- salt
- Blowfish
- Elliptic Curve Cryptography(ECC)(DecryptEncrypt)
- Sha1、Sha256(DecryptEncrypt)
- DES(DecryptEncrypt)
- rc4(DecryptEncrypt)
- brainfuck
- jsfuck https://github.com/aemkei/jsfuck (https://github.com/dNetGuru/JSUNFuck)
- Base16(Code)
- Compressed file pseudo encryption(Including normal encryption and decryption(Need other libraries))
- Tencent TEA algorithm[根据腾讯公开的JS文件分析QQTEA算法](http://blog.csdn.net/gsls200808/article/details/70837455)
- wordpress user's password encryption[wordpress用户密码加密原理及其算法分析](https://blog.csdn.net/HK_JH/article/details/27368279)
- php serialization and deserialization
- baze64（https://github.com/xanderma/QQ-Confess/blob/master/src/Baze64.java）

Class Files
|——Files Reverse
|——Files Read$Write

Class string
|——string reverse by words and bytes
|——Regular match returns an array of results
|——word and byte conversion

## about
[My Blog](https://willv.cn)

[About this project](https://willv.cn/projects/Crypto)

## LICENSE
Apache