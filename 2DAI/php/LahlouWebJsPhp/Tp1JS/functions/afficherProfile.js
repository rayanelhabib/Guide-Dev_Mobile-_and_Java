function afficherProfile() {
    const storedData = localStorage.getItem('userData');
    
    if (!storedData) {
        alert('Aucune donnée utilisateur trouvée. Veuillez vous connecter.');
        window.location.href = 'login.html';
        return;
    }
    
    const userData = JSON.parse(storedData);
    
    const nomElement = document.getElementById('nom');
    const telephoneElement = document.getElementById('telephone');
    const emailElement = document.getElementById('email');
    const passwordElement = document.getElementById('password');
    
    if (nomElement) {
        nomElement.textContent = userData.nom;
    }
    
    telephoneElement && (telephoneElement.textContent = userData.telephone || 'Non spécifié');
    
    if (emailElement) {
        emailElement.textContent = userData.email;
    }
    
    if (passwordElement) {

        passwordElement.textContent = userData.password; 
    }
}