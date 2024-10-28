function showAlert(message) {
    const alertInfo = document.getElementById('alertInfo');
    alertInfo.querySelector('div').innerText = message;
    alertInfo.style.display = 'flex'; 
    
    setTimeout(() => {
        hideAlert();
    }, 2000);
}

function hideAlert() {
    const alertInfo = document.getElementById('alertInfo');
    alertInfo.style.display = 'none';
}