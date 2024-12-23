function testorder(productId) {
    var productsId = productId;
    $.ajax({
        url: '@Url.Action("Add_Order_into_List", "Product")',
        type: 'POST',
        dataType: 'json',
        data: {
            ProductId: productsId
        },
        success: function (response) {
            debugger;
            var Order_List = '';
            if (response && response.length > 0) {
                $("#Order_List_Table tbody").empty();
                var j = 1;
                for (var i = 0; i < response.length; i++) {
                    Order_List += `
                                        <tr>
                                        <td>${j}</td>
                                        <td>${response[i].itemName}</td>
                                        <td>${response[i].price}</td>
                                        <td class="product-quantity">${response[i].quantity}</td>
                                        <td class="product-amount">${response[i].amount}</td>
                                        </tr> `;
                    j++;
                }

                $("#Order_List_Table tbody").html(Order_List);
            }
            else {
                alert("error fetching bill");
            }
        },
        error: function (xhr, status, error) {
            alert("error");
        }


    })
}