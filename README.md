# Crypto
封装多种CTF和平时常见加密及编码C#类库

我的博客里写了一些类库里各种加密及函数的介绍和分析。[标签: Crypto | 时光](https://willv.cn/tags/Crypto/)

[English](https://github.com/WWILLV/Crypto/blob/master/README-en.md)

## 支持的编码及加密

### DecryptEncrypt
- 32/16位MD5
- 异或加解密（可选返回值是否为Base64）
- 凯撒加密
- Rot13
- AES（128位ECB、CBC）
- 培根密码
- 栅栏密码
- 维吉尼亚密码

### Code
- Base64/32加解密
- 摩斯加解密（暂时只支持字母和数字）
- url
- ASCII及Unicode和字符串的3者互转

### Conversion
- 任意进制转换(最高支持62进制转换，暂不支持小数)

## Todo
- RSA(DecryptEncrypt)
- CRC32
- 曼彻斯特编码
- 差分曼彻斯特编码
- 补码反码
- 加盐
- Blowfish
- 椭圆曲线加密ECC(DecryptEncrypt)
- Sha1、Sha256(DecryptEncrypt)
- DES(DecryptEncrypt)
- rc4(DecryptEncrypt)
- brainfuck
- jsfuck https://github.com/aemkei/jsfuck (https://github.com/dNetGuru/JSUNFuck)
- Base16(Code)
- 压缩文件伪加密（包括正常的加解密（可能需要其他类库））
- 腾讯TEA算法[根据腾讯公开的JS文件分析QQTEA算法](http://blog.csdn.net/gsls200808/article/details/70837455)
- wordpress用户密码加密[wordpress用户密码加密原理及其算法分析](https://blog.csdn.net/HK_JH/article/details/27368279)
- php序列化和反序列化
- baze64（https://github.com/xanderma/QQ-Confess/blob/master/src/Baze64.java）

cryptofile
|——文件逆转
|——文件流读取写入 直接读取文件流到byte数组或string
可以直接对文件流操作，不一定要有文件，必要时新建临时文件
对文件流执行fileinfo等操作

fileinfo类
直接读取文件的md5，sha等相关信息


字符串类
|——字符按字节或字符逆转
|——正则匹配返回结果数组
|——字符和字节互相转换

## 关于
[作者主页](https://willv.cn)


## LICENSE
Apache