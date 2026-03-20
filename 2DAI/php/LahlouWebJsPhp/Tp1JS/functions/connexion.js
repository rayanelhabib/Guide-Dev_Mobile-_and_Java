function connexion() {
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    
    if (email === '' || password === '') {
        alert('Veuillez remplir tous les champs');
        return false;
    }
    
    if (typeof emailValide === 'function') {
        if (!emailValide(email)) {
            alert('Email invalide');
            return false;
        }
    } else if (!window.emailValide(email)) {
        alert('Email invalide');
        return false;
    }
    
    const storedData = localStorage.getItem('userData');
    
    if (!storedData) {
        alert('Aucun compte trouvé. Veuillez vous inscrire.');
        return false;
    }
    
    const userData = JSON.parse(storedData);
    
    if (userData.email === email && userData.password === password) {
        window.location.href = 'profile.html';
        return true;
    } else {
        alert('Email ou mot de passe incorrect');
        return false;
    }
}

export { connexion };