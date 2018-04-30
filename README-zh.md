# Crypto
封装多种CTF和平时常见加密及编码C#类库

我的博客里写了一些类库里各种加密及函数的介绍和分析。[标签: Crypto | 时光](https://willv.cn/tags/Crypto/)

## 支持的编码及加密
- 32/16位MD5(DecryptEncrypt)
- Base64/32加解密(Code)
- 异或加解密（可选返回值是否为Base64）(DecryptEncrypt)
- 凯撒加密(DecryptEncrypt)
- Rot13(DecryptEncrypt)
- 摩斯加解密（暂时只支持字母和数字）(Code)
- AES（128位ECB、CBC）(DecryptEncrypt)
- 培根密码(DecryptEncrypt)
- 栅栏密码(DecryptEncrypt)
- 维吉尼亚密码(DecryptEncrypt)
- 任意进制转换(最高支持62进制转换，暂不支持小数)(Conversion)
- url(Code)
- ASCII及Unicode和字符串的3者互转(Code)

## Todo
- RSA(DecryptEncrypt)
- 椭圆曲线加密ECC(DecryptEncrypt)
- Sha1、Sha256(DecryptEncrypt)
- DES(DecryptEncrypt)
- rc4(DecryptEncrypt)
- brainfuck
- jsfuck
- Base16(Code)
- 压缩文件伪加密（包括正常的加解密（需要其他类库））
- 腾讯TEA算法[根据腾讯公开的JS文件分析QQTEA算法](http://blog.csdn.net/gsls200808/article/details/70837455)

## 关于
[作者主页](https://willv.cn)

[关于该项目](https://willv.cn/projects/Crypto)

## LICENSE
Apache