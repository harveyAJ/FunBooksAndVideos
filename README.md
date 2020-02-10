# FunBooksAndVideos e-commerce shop

## Introduction

FunBooksAndVideos is an e-commerce shop where customers can view books and watch online videos. Users can have memberships for the book club, the video club or for both clubs (premium).

## Purchase Order

A purchase order can contain products or membership requests. A purchase order has an PO ID, a customer ID and total price. There is an item line in the purchase order per product purchased (product, membership type). One example of a purchase order is the following:

Purchase Order: 3344656
Total: 48.50
Customer: 4567890
Item lines:

* Video "Comprehensive First Aid Training"
* Book "The Girl on the train"
* Book Club Membership

## Business Rules

Several business rules are applied when a purchase order is processed. The rules that should be implemented are:
* BR1. If the purchase order contains a membership, it has to be activated in the customer account immediately.
* BR2. If the purchase order contains a physical product a shipping slip has to be generated.

Examples of additional rules that could be used:
* BR3. If the purchase order contains Comprehensive First Aid Training video then Basic First Aid training video is added to the purchase order.
* BR4. If the purchase order contains books, and the customer has book membership or bought one then 5 points are added to the customer account for each book.
* BR5. If the purchase order contains videos, and the customer has video club membership or bought one then 5 points are added to the customer account for each video.

## Tasks

* Implement an Object Oriented model of the system
* Design a purchase order processor with a flexible rules engine
* Implement the first two business rules.