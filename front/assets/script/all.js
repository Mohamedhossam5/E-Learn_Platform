// all.js

function injectHeadContent() {
    fetch('../../components/head.html')
        .then(response => response.text())
        .then(data => {
            const parser = new DOMParser();
            const doc = parser.parseFromString(data, 'text/html');
            const headContent = doc.head.childNodes;
            
            headContent.forEach(node => {
                document.head.appendChild(node.cloneNode(true));
            });
        })
        .catch(error => {
            console.error('Error loading head content:', error);
        });
}

document.addEventListener('DOMContentLoaded', injectHeadContent);

