# 创建性模式 (Creational)
## Singleton
解决的事实体对象个数的问题. 除了Singleton之外, 其他创建型模式解决的都是new所带来的耦合关系

## Factory Method, Abstract Factory, Builder
都需要一个额外的工厂类来负责实例化“易变对象”, 而Prototype则是通过原型(一个特殊的工厂类)来克隆“易变对象”

如果遇到“易变类”, 起初的设计通常从Factory Method开始, 当遇到更多的复杂变化时, 再考虑重构为其他三种工厂模式(Abstract Factory, Builder, Prototype)

# 结构型模式 (Structural)
## Adapter
注重转换接口, 将不吻合的接口适配对接

## Bridge
注重分离接口与其实现, 支持多维度变化

## Composite
注重统一接口, 将“一对多”的关系转化为“一对一”的关系

## Decorator
注重稳定接口, 在此前提下为对象扩展功能

## Facade
注重简化接口, 简化组件系统与外部客户程序的依赖关系

## Flyweight
注重保留接口, 在内部使用共享技术对对象存储进行优化

## Proxy
注重假借接口, 增加间接层来实现灵活控制

# 行为型模式 (Behavioral)
## Template Method
封装算法结构, 支持算法子步骤变化

## Strategy
注重封装散发, 支持算法的变化

## State
注重封装与状态相关的行为, 支持状态的变化

## Memento
注重封装对象状态变化, 支持状态保存/恢复

## Mediator
注重封装对象间的交互, 支持对象交互的变化

## Chain of Responsibility
注重封装对象责任, 支持责任的变化

## Command
注重将请求封装为对象, 支持请求的变化

## Iterator
注重封装集合对象内部结构, 支持集合的变化

## Interpreter
注重封装特定领域变化, 支持领域问题的频繁变化

## Observer
注重封装对象通知, 支持通信对象的变化

## Visitor
注重封装对象操作变化, 支持在运行时为类层次结构动态添加新的操作

# Relationships
![](./pattern-relationships.jpg)