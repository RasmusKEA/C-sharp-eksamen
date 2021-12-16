require('dotenv').config()
const express = require("express")
const app = express()

app.use(express.static("public"));

app.use(express.json());
app.use(express.urlencoded({ extended: true }));


const { createPage } = require("./render.js");
const { urlencoded } = require("express"); 

const indexPage = createPage('index/index.html')
const aboutPage = createPage('about/about.html')
const toursPage = createPage('tours/tours.html')
const mapPage = createPage('map/map.html')
const loginPage = createPage('login/login.html')
const adminPage = createPage('admin/admin.html')
const createTourPage = createPage('create/create.html')
const editPage = createPage('edit/edit.html')
const tourPage = createPage('tour/tour.html')

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

app.get('/create', (req, res)=> {
    res.send(createTourPage)
})

app.get('/edit', (req, res) => {
    res.send(editPage)
})

app.get('/tour/:id', (req, res) => {
    res.send(tourPage)
})




const PORT = process.env.PORT || 8080;

app.listen(PORT, (error) => {
    console.log("Server is running on", PORT);
});