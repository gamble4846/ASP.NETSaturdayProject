function UpdateClick(id, name, cuisine, price, quantity) {
    document.getElementById('UpdateId').value = id;
    document.getElementById('UpdateName').value = name;
    document.getElementById('UpdateCuisine').value = cuisine;
    document.getElementById('UpdatePrice').value = price;
    document.getElementById('UpdateQuantity').value = quantity;
    $('#updateModal').modal('show');
}