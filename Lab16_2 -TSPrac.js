var mountains = [
    { name: 'Kilimanjaro', height: 19341 },
    { name: 'Everest', height: 29029 },
    { name: 'Denali', height: 20310 }
];
function findNameOfTallestMoutain(mts) {
    var tallest = '';
    var height = 0;
    mts.forEach(function (mt) {
        if (mt.height > height) {
            height = mt.height;
            tallest = mt.name;
        }
    });
    return tallest;
}
console.log("Tallest in Mountains: " + findNameOfTallestMoutain(mountains));
var products = [
    { name: 'Item A', price: 24.95 },
    { name: 'Item B', price: 15.50 },
    { name: 'Item C', price: 5.50 },
    { name: 'Item D', price: 125.99 },
    { name: 'Item E', price: 39.95 },
    { name: 'Item F', price: 250.00 },
    { name: 'Item G', price: 3.20 },
    { name: 'motor', price: 10.00 },
    { name: 'sensor', price: 12.50 },
    { name: 'LED', price: 1.00 }
];
function calcAverageProductPrice(prods) {
    var total = 0;
    prods.forEach(function (p) { total += p.price; });
    var avg = total / prods.length;
    return avg;
}
var Avg = calcAverageProductPrice(products);
console.log("Average of products in array: " + Avg);
var inventory = [
    { product: products[7], quantity: 10 },
    { product: products[8], quantity: 4 },
    { product: products[9], quantity: 20 }
];
function calcInventoryValue(inv) {
    var total = 0;
    inv.forEach(function (item) {
        total += item.product.price * item.quantity;
    });
    return total;
}
var invTotal = calcInventoryValue(inventory);
console.log("Total inventory value: " + invTotal);
