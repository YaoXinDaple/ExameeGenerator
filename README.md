# ExameeGenerator

## 数据库迁移

### Add Migrations

```powershell
cd .\src\ExameeGenerator.Infrastructure\
dotnet ef migrations add Init --context AppDbContext --output-dir Migrations
```


### Apply Migrations
`dotnet ef database update`

## 项目架构
使用整洁架构搭建了项目骨架。Domain项目为核心，不依赖其他项目。Infrastructure项目依赖Application。

Application中需要使用的第三方服务，通过定义接口由Infrastructure负责实现改接口。通过这种端口适配器模式实现控制反转。

ORM框架使用的为EFCore。实体的Id使用的是默认Guid方案，真实项目中一般会使用GuidV7，或者自定义的有序Guid生成器。

应用服务层使用了REPR 极简设计模式，实际项目中可以通过MediatR，实现更近一步的解耦。

## 单元测试
主要测试三部分内容

- 项目现有架构依赖关系不允许被破坏
- Domain中实体对外部的承诺，必须全部被验证，需要抛出异常的情况应当抛出异常
- 应用服务层主要测试执行业务逻辑过程中调用的服务是否调用了指定的次数。如：GetById中 IExamRepository应该被且仅被调用一次。

