let tourID = localStorage.getItem("tourID")

fetch(`http://localhost:5000/api/tour/gettour/${tourID}`)
.then(response => response.json())
.then((result) => {
    const tourWrapperDiv = document.getElementById("wrapper");
    console.log(result)

    result.map(result => { 
        const tourDiv = document.getElementById("left-div");
        
        tourDiv.className = "tour-div"
        tourDiv.innerHTML = `
            <h4>${result.name}</h4>
            <span>Beskrivelse: <br>
            ${result.description}
            <br> <br>
            </span>
            <p>Milepæle: ${result.milestones}</p>
            <p>Afstand: ${result.distance} km</p>
            <p>Tid: ${result.time}</p>
        `;
        
        tourWrapperDiv.appendChild(tourDiv);

        const rightDiv = document.getElementById("right-div");

        const img = document.createElement('img')
        img.setAttribute('src', `${result.image}`)
        img.setAttribute('width', '400px')
        img.setAttribute('height', '400px')

        rightDiv.append(img)
        tourWrapperDiv.appendChild(rightDiv)


    });
});