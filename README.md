# Crypto
封装多种CTF和平时常见加密及编码C#类库

我的博客里写了一些类库里各种加密及函数的介绍和分析。[标签: Crypto | 时光](https://willv.cn/tags/Crypto/)

[English](https://github.com/WWILLV/Crypto/blob/master/README-en.md)

## 支持的编码及加密

### DecryptEncrypt
- 加盐(可随机生成)
- 32/16位MD5
- 异或加解密（可选返回值是否为Base64）
- 凯撒加密
- Rot13
- 培根密码
- 栅栏密码
- 维吉尼亚密码
- AES（128位ECB、CBC）
- Sha1、Sha256

### Code
- Base64/32加解密
- 摩斯加解密（暂时只支持字母和数字）
- url
- ASCII及Unicode和字符串的3者互转

### Conversion
- 任意进制转换(最高支持62进制转换，暂不支持小数)

### CryptoFileInfo
- 获取文件md5
- 获取文件Sha1
- 获取文件Sha256
- （FileInfo）获取文件名、扩展名、大小、创建时间上次访问和写入时间、属性

### Cryptofile
- 逆转文件到新文件
- 文件读取到字节数组或字符串
- 字节数组或字符串写入到文件
- 对临时文件操作（CryptoFileInfo支持）

### CryptoString
- 生成随机字符串
- 反转字符串
- 字符串、字节数组、流互转
- 正则匹配返回结果数组
- 常用字符串、正则表达式


## Todo
- RSA
- CRC32
- 曼彻斯特编码
- 差分曼彻斯特编码
- 补码反码
- Blowfish
- 椭圆曲线加密ECC
- DES
- rc4
- brainfuck
- jsfuck https://github.com/aemkei/jsfuck (https://github.com/dNetGuru/JSUNFuck)
- aaencode
- Base16
- 压缩文件伪加密（包括正常的加解密（可能需要其他类库））
- 腾讯TEA算法[根据腾讯公开的JS文件分析QQTEA算法](http://blog.csdn.net/gsls200808/article/details/70837455)
- wordpress用户密码加密[wordpress用户密码加密原理及其算法分析](https://blog.csdn.net/HK_JH/article/details/27368279)
- php序列化和反序列化
- baze64（https://github.com/xanderma/QQ-Confess/blob/master/src/Baze64.java）
- gzip，utf8等转换 
- 【检测加密类型】

维吉尼亚密钥破解  http://www.practicalcryptography.com/cryptanalysis/stochastic-searching/cryptanalysis-vigenere-cipher/ 

## 关于
[作者主页](https://willv.cn)


## LICENSE
Apache