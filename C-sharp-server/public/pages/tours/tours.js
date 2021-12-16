fetch("http://localhost:5000/api/tour/gettours")
.then(response => response.json())
.then((result) => {
    const tourWrapperDiv = document.getElementById("tour-container wrap");
    console.log(result)

    result.map(result => { 
        const tourDiv = document.createElement("div");
        
        tourDiv.className = "tour-div"
        tourDiv.innerHTML = `
            <h4>${result.name}</h4>
            <p>Milepæle: ${result.milestones}</p>
            <p>Afstand: ${result.distance} km</p>
            <p>Tid: ${result.time}</p>
        `;

        const editButton = document.createElement("button")
        editButton.className = "btn btn-primary shadow-none dl-cv edit-button"
        editButton.id = result.idroutes
        editButton.innerHTML = "Se touren"
        
        tourDiv.append(editButton)
        tourWrapperDiv.appendChild(tourDiv);

        editButton.onclick = function (){
            location.href = `/tour/${result.idroutes}`
            localStorage.setItem("tourID", result.idroutes)
        }

    });
});