function inscription() {
    const nom = document.getElementById('nom').value;
    const telephone = document.getElementById('telephone').value;
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    
    if (nom === '' || telephone === '' || email === '' || password === '') {
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
    
    const userData = {
        nom: nom,
        telephone: telephone,
        email: email,
        password: password
    };
    
    localStorage.setItem('userData', JSON.stringify(userData));
    
    alert('Inscription réussie! Bienvenue ' + nom);
    
    window.location.href = 'login.html';
    
    return true;
}

export { inscription };