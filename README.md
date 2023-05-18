# Limit Order Book
-----
## Technical Explaination
* It's the records of outstanding limit orders maintened by the security specialist who works at the exchange markets.
* When a limit order for a security is entered, it is kept on record by the security specialist.
* As [buy](https://www.ig.com/za/trading-strategies/buying-and-selling-in-trading-explained-190430) and [sell](https://www.ig.com/za/trading-strategies/buying-and-selling-in-trading-explained-190430) limit orders for the security are given, the specialist keeps a record of all of the orders in the order book.

[Security Specialist:](https://www.investopedia.com/terms/s/specialist.asp) has the responsibility to guarantee that the top priority order is executed before other orders in the book, and before other orders at an equal price or worse price held or submitted by other traders on the floor, such as brokers.

![pic](https://github.com/MinenhleNkosi/LimitOrderBook/blob/main/images/4.png)

## Simpler Explaination
* Imagine you have a toy that you want to **sell** to someone. You decide that you won't **sell** it for **less than R10**. So you put a sign next to the toy that says `"Toy for sale, R10 or more"`.
* Someone comes along and sees the sign. They want the toy and are willing to **pay R11** for it. So they **write a note** that says `"I'll buy the toy for R11"`. They give the note to you, and you put it in your **pocket**.
* Another person comes along and sees the sign too. They also want the toy, but they are only willing to **pay R9** for it. So they **write a note** that says `"I'll buy the toy for R9"`. They give the note to you, and you put it in your **pocket**.
* Now you have two **notes** in your **pocket** - one for R11 and one for R9. You look at the **notes** and decide that you'll **sell** the toy to the person who offered **R11** because that's more than **R10**.

* That's kind of like what a [limit order book](https://www.investopedia.com/terms/l/limitorderbook.asp) does for the stock market. Instead of toys, people **buy** and **sell** pieces of companies called stocks. And instead of **notes** they **use computers** to place **orders** to **buy or sell** the stocks at a certain **price**.
* The **limit order book** organizes all of these **orders** by **price**, with the highest buying price and the lowest selling price at the top. This helps traders know what other people are willing to pay for the stock and what other people are willing to sell it for.
* Just like you decided to sell the toy to the person who offered the most money, traders can use the **limit order book** to decide whether they want to **buy or sell** a stock based on what other people are offering to pay for it. And just like you kept the **notes** in your pocket until you decided to sell the toy, the **computer** keeps track of all the orders until they are executed, or until the trader decides to cancel them.

That's basically what a limit order book does - `it helps organize and display all the buy and sell orders for stocks so that traders can make informed decisions about what to buy or sell and at what price`.

-----
## Limit Order
* It's a type of order used to **Buy** or **Sell** a security at a specific price or better.

## Security
* Refers to a financial asset that can be bought or sold such as **stock**, **bonds**, etc.
* It's what you own and can be traded on financial markets like [stock exchange](https://www.investopedia.com/articles/basics/04/092404.asp) or [over-the-counter (oct)](https://www.forbes.com/advisor/investing/otc-market/) markets.

![pic](https://github.com/MinenhleNkosi/LimitOrderBook/blob/main/images/2.png)

![pic](https://github.com/MinenhleNkosi/LimitOrderBook/blob/main/images/3.png)

## Buy
* Is a limit order to "buy" a security at a **present** price or lower.

## Sell
* It's a limit order to "sell" a security at a pre-specified price or higher.

![pic](https://github.com/MinenhleNkosi/LimitOrderBook/blob/main/images/1.jpg)

-----
## Tracking a Limit Order
The system matches the execution of the best possible pair of orders in the system. The best pair is made up of the highest **bid** and the lowest **ask** orders.

![pic](https://github.com/MinenhleNkosi/LimitOrderBook/blob/main/images/5.png)

* **Bid:** Is the price the specialist or exchange will `sell` a security or the price at which an investor can `buy` a security.
* **Ask:** Offers the price at which the specialist or exchange will `buy` a security or the price at which the investor can `sell` the security.

----
# The Project
1. We are going to build an `Order Limit Book` the stores the states of all the orders running on the server.
2. The `Order Limit Book` will allow you to **add an order**, **change an order**, and **remove an order** in an effecient and quick way.
3. We sort our **Asks** in an ascending fashion.
4. We sort our **Bids** in a descending fashion.
5. We are able to retrieve information on whether an order exists or not.
6. We are able to get the amount of **Counts** of the order (which is a total number of a specific order) in the Limit Order Book in [O(1)](https://www.freecodecamp.org/news/big-o-notation-why-it-matters-and-why-it-doesnt-1674cfa8a23c/) time.

----
## Part 1: Engine Server
* The clients will be consuming the market data on the server we are going to create and make decisions on the data they recieve, those decisions could be `to cancel an order`, `submit a new order`, `delete an existing order`.

![pic](https://github.com/MinenhleNkosi/LimitOrderBook/blob/main/images/6.png)

* For in-depth explaination on [Part 1](insert link to part 1 folder)


## Part 2: Logging Facility, OrderTypes, Responses & Rejection
* The main goal here is to develop a comprehensive logging facility or library that will serve as a robust logging system. This system is designed to handle various types of logs, specifically focusing on capturing and storing data related to limit orders. 
* The primary objective of this logging facility is to provide a reliable and efficient means of recording and retrieving essential information pertaining to limit orders, ensuring that relevant data is preserved for analysis and future reference.

![pic](https://github.com/MinenhleNkosi/LimitOrderBook/blob/main/images/7.png)

*For in-depth expalination on [Part 2](insert link to part 2 folder)

## Part 3: Matching Algorithms, and Test Units
* This part is still a **work in progress** but will be uploaded `SOON`.

-----
## Build

### Prerequisites
* Visual Studion 2022
* .NET 6

### Installation
**1. Clone repo:**

```
https://github.com/MinenhleNkosi/LimitOrderBook.git
```

**2. Directory Path:** Replace "change me" on the `appsetting.json` file with your directory path.

```
"Directory": "change me",
````

------
