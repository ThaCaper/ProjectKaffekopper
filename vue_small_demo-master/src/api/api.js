import axios from 'axios';

export default axios.create({
    baseURL: `http://coffeecupshop.azurewebsites.net/api/coffeeCups`,
    headers: {
        'Content-Type': 'application/json',
        // 'Authorization': "JWT " + localStorage.getItem('token')
    },
    // xsrfCookieName: 'csrftoken',
    //xsrfHeaderName: 'X-CSRFToken',
    // withCredentials: true
});