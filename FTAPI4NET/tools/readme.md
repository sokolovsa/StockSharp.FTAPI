说明：本目录下放置项目中需要用到的工具。

## protoc.exe和ProtoGen.exe

用于将proto文件转为csharp代码。用法：

1. 假设目录结构如下：
    ```
    |-- pb  放置proto文件
    |-- out 放置生成的中间文件
    |-- outcs 放置最终的cs文件
    |-- protoc.exe 将proto文件转为protobin文件
    |-- ProtoGen.exe 将protobin转为cs文件
    ```
2. 将f.proto转为protobin文件：
    ``` 
    protoc.exe -Ipb--descriptor_set_out=out\f.protobin --include_imports pb\f.proto 
    ```
3. 生成cs文件：
    ```
    ProtoGen.exe  -namespace=Futu.OpenApi.Pb -nest_classes=true -output_directory=outcs out\f.protobin
    ```

注意：由于工具问题，Notify.proto最终生成的cs文件有语法问题，需要将第504行：
```
if (!ProgramStatus.IsInitialized) return false;
```
改为：
```
if (!programStatus_.IsInitialized) return false;
```