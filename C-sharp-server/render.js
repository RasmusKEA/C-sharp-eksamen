const fs = require("fs");

const nav = fs.readFileSync("./public/global/nav/nav.html", "utf8");
const footer = fs.readFileSync("./public/global/footer/footer.html", "utf8");

function createPage(path, options) {
    return (nav + fs.readFileSync(`./public/pages/${path}`, "utf8") + footer)
            .replace("%%DOCUMENT_TITLE%%", options?.title || "Nodefolio")
            .replace("%%SCRIPT_PLACEHOLDER%%", options?.scriptTag || "");
}

module.exports = {
    createPage
};