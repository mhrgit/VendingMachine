One of the solutions as an option was to produce state machine pattern. I thought as this is a simple vending machine, I ommit the 
state machine implementation. 

- When solution is implemented, interfaces are used and constructor based dependency injection pattern used for decoupling and unit testing purposes. 

- Nunit framework is used for unit testing.

- Vending machine is structured with singleton pattern.

The solution consists of two main projects: Core and Tests.

- Ideally order manager and services folders could be seperated into two different projects.

- Order manager is the place where an order is processed. It needs a vending machine and account instance to operate. Order manager checks 
all necessary conditions before updating account balance and vending machine inventory, also updates the state of the account and the machine.

- Lock is used in order manager to prevent access and making changes from multiple threads. This situation is covered with unit tests.

- Tests are separated for account balance tests, machine inventory tests, concurrent access tests. 