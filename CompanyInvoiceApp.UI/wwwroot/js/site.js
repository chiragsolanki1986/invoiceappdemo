// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function printDoc()
{
   var invoiceDiv=$("#invoicediv");   
   newWin= window.open("");
   newWin.document.write(invoiceDiv.html());
   newWin.print();
   newWin.close();
}

function focuseventhandler() {
   $('#printbtn').show();
}

$('#printbtn').on('click',function(){
   $('#printbtn').hide();
   //printDoc();
   window.addEventListener('afterprint', focuseventhandler);
   window.print();
})

