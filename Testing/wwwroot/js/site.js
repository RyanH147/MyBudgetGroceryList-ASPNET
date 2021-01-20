
{
    let subTotal = document.getElementById('subtotal');
    let taxRate = document.getElementById('tax_rate');
    let salesTax = document.getElementById('sales_tax');
    let total = document.getElementById('total');
    let calculate = document.getElementById('calculate');

    let round = (number, decimals) => Number(`${Math.round(`${number}e+${decimals}`)}e-${decimals}`);
    let calculateSalesTax = (amount, rate) => rate / 100 * amount;
    let calculateTotal = (amount, tax) => amount + tax;

    let processEntries = () => {
        let amount = parseFloat(subTotal.value);
        let rate = parseFloat(taxRate.value);
        if ((!amount && amount !== 0) || (!rate && rate !== 0)) {
            alert("Both entries must be numeric");
            return null;
        }
        let taxAmount = calculateSalesTax(amount, rate);
        let totalAmount = calculateTotal(amount, taxAmount);
        salesTax.value = round(taxAmount, 2).toFixed(2);
        total.value = round(totalAmount, 2).toFixed(2);
    };

    calculate.addEventListener('click', processEntries, false);
}

