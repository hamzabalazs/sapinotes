import React, { useRef, useState } from "react";

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
  const [selectedNote, setSelectedNote] = useState();
  const popupRef = useRef();

  const Download = async documentId => {
    console.log("hll");
    const response = await getDoc(documentId);
    console.log(response);
    downloadfile(documentId, response.documentName);
  };

  const openPopUp = async note => {
    if (popupRef.current) {
      popupRef.current.classList.remove("hidden");
    }
  };
  const closePopUp = () => {
    if (popupRef.current) {
      popupRef.current.classList.add("hidden");
    }
  };

  return (
    <div
      className="hidden fixed overflow-y-auto overflow-x-hidden top-0 left-0 bottom-0 right-0 z-50 flex items-center justify-center bg-black/60"
      ref={popupRef}
    >
      <div className="grid grid-cols-3 gap-4">
        {props.noteList.map((note, index) => (
          <div
            key={`NoteList-${index}`}
            className="p-4 bg-orange-500 rounded-xl "
          >
            <div className="text-lg font-bold">{note.noteName}</div>

            <button id="download" onClick={() => Download(note.noteDocID)}>
              Download Note
            </button>
          </div>
        ))}
      </div>
    </div>
  );
};

export default NoteList;
