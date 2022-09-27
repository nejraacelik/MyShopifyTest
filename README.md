# shopifyTest
In this test I used Selenium Automation framework with C# in Chrome environment. For this packet I used nuget packege [QATest.Setup](https://github.com/nejraacelik/QATest.Setup) which is also made by me.

### Initialization: MyShopifyBaseTest
- Open browser
- Visit URL(“https://qa-practical-test.myshopify.com”)
- Enter website password: brauff
- Redirect to “Catalog” by clicking it from top/header navigation menu

### Test 1 : Cart_ItemIsInCart
- Add 1st Product to cart
- Cart Page: Verify Product Price (Without Offer)

### Test 2 : Cart_FirstDiscountOffer
- Increase Quantity to eligible for discount offer 1st Offer
- Verify Product Price (With discount Applied)

### Test 3: Cart_SecondDiscountOffer
- Increase Quantity to eligible for discount offer 2nd Offer
- Verify Product Price (With discount Applied)

### Test 4: Cart_ThirdDiscountOffer
- Increase Quantity to eligible for discount offer 3rd Offer

### Test 5: Cart_ProductLinePriceCart
- Verify Product Price (With discount Applied)
- Verify Line Item price and product price on checkout page

### Test 6: Cart_CheckOutTotalAndDiscountPrice
- Verify Total and Discount price on checkout page.