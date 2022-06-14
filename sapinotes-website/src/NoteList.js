import React from "react";

async function getDoc(documentId) {
  let urlDoc = "https://localhost:7214/api/Documents/get-doc?id=" + documentId;
  return fetch(urlDoc, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
    },
  }).then(data => data.json());
}

function downloadfile(documentId, documentName) {
  let urlDownload =
    "https://localhost:7214/api/Documents/download-by-id?id=" + documentId;

  fetch(urlDownload, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
  })
    .then(resp => resp.blob())
    .then(blob => {
      const url = window.URL.createObjectURL(blob);
      console.log(blob);

      const a = document.createElement("a");
      a.style.display = "none";
      a.href = url;
      // the filename you want
      a.download = documentName;
      document.body.appendChild(a);
      a.click();
      window.URL.revokeObjectURL(url);
    })
    .catch(() => alert("oh no!"));
}

const NoteList = props => {
  const Download = async documentId => {
    console.log("hll");
    const response = await getDoc(documentId);
    console.log(response);
    downloadfile(documentId, response.documentName);
  };

  return (
    <div className="grid grid-cols-3 gap-4">
      {props.noteList.map((note, index) => (
        <div key={`NoteList-${index}`} className="listElement ">
          <div className="text-lg font-bold">{note.noteName}</div>
          <div className="text-lg font-bold">{note.username}</div>
          <br />
          <button id="download" onClick={() => Download(note.noteDocID)}>
            Download Note
          </button>
        </div>
      ))}
    </div>
  );
};

export default NoteList;
