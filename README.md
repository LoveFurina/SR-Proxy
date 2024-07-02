# SR-Proxy
 代理转向工具

本人一键端所使用的代理，派生自Tart的FreeSR

默认会将流量重定向至 `localhost:21000`
# 编译
### 需求
.NET 7.0 SDK
```shell
git clone https://github.com/LoveFurina/SR-Proxy
cd SR-Proxy
dotnet build
```
编译完的程序可在 bin 文件夹里找到
# 说明
- 程序使用系统代理进行流量重定向，会与其它代理软件的系统代理模式冲突(TUN模式不受影响)
- 若要用它代理LC等部分服务端，记得关闭 `httpServer` 的 HTTPS/SSL 功能并修改端口
- 如果直接使用release里面编译好的程序，且出现闪退(窗口闪一下就关)，请安装.NET 7.0(SDK或runtime均可)
