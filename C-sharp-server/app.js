require('dotenv').config()
const express = require("express")
const app = express()
const cookieParser = require("cookie-parser");
const sessions = require('express-session');

app.use(express.static("public"));

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

const oneDay = 1000 * 60 * 60 * 24;
//session middleware
app.use(sessions({
    secret: process.env.ACCESS_TOKEN_SECRET,
    rolling: true,
    saveUninitialized:true,
    cookie: { maxAge: oneDay },
    resave: false
}));

app.use(cookieParser());
var session;


const { createPage } = require("./render.js");
const { urlencoded } = require("express"); 

const indexPage = createPage('index/index.html')
const aboutPage = createPage('about/about.html')
const toursPage = createPage('tours/tours.html')
const mapPage = createPage('map/map.html')
const loginPage = createPage('login/login.html')
const adminPage = createPage('admin/admin.html')

app.get('/', (req, res) =>{
    res.send(indexPage)
})

app.get('/about', (req, res) =>{
    res.send(aboutPage)
})

app.get('/tours', (req, res) =>{
    res.send(toursPage)
})

app.get('/map', (req, res) =>{
    res.send(mapPage)
})

app.get('/login', (req, res) =>{
    res.send(loginPage)
})

app.get('/admin', (req, res) =>{
    res.send(adminPage)
})


const PORT = process.env.PORT || 8080;

app.listen(PORT, (error) => {
    console.log("Server is running on", PORT);
});