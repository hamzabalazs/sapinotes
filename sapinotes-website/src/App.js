import React, { useEffect, useState } from "react";
import Header from "./Header";
import NoteList from "./NoteList";
import { useNavigate } from "react-router-dom";
import Select from "react-select";

async function downloadfile(documentID, documentName) {
  let urlDownload =
    "https://localhost:7214/api/Documents/download-by-id?id=" + documentID;

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

function App() {
  const [majorList, setMajorList] = useState([]);
  const [subjectList, setSubjectList] = useState([]);
  const [subject, setSubject] = useState();
  const [major, setMajor] = useState();
  const [noteList, setNoteList] = useState([]);

  const getMajorList = async () => {
    let url = "https://localhost:7214/api/Majors/getmajors";
    fetch(url)
      .then(response => response.json())
      .then(output => {
        setMajorList([...majorList, ...output]);
      });
  };

  const getNoteList = async subjectId => {
    let url =
      "https://localhost:7214/api/Notes/get-notes-of-subject?subjectId=" +
      subjectId;
    fetch(url)
      .then(response => response.json())
      .then(output => {
        setNoteList([...noteList, ...output]);
      });
  };

  const getSubjectList = async majorId => {
    let url =
      "https://localhost:7214/api/Subjects/get-subjects-of-major?majorId=" +
      majorId;
    fetch(url)
      .then(response => response.json())
      .then(output => {
        setSubjectList([...subjectList, ...output]);
      });
  };

  const fillSubjectDropdown = () => {
    if (major !== undefined) {
      let id = major.majorID;
      getSubjectList(id);
    } else getSubjectList(0);
  };

  const emptySubjectList = () => {
    setNoteList([]);
    setSubjectList([]);
  };

  const fillNoteList = () => {
    if (subject !== undefined) {
      let id = subject.subjectID;
      getNoteList(id);
    } else getNoteList(0);
    console.log(noteList);
  };

  const downloadNote = () => {};

  const navigate = useNavigate();
  useEffect(() => {
    getMajorList();
    setNoteList([]);
    if (!localStorage.getItem("user-info")) {
      navigate("/login");
    }
  }, []);

  return (
    <div>
      <Header />
      <div className="bodydiv-with-nav">
        <h2>Welcome to Sapinotes</h2>
        <h4>Select major and subject to list notes</h4>
        <div className="col-sm-6 offset-sm-3">
          <label>Major</label>
          <Select
            name="majors"
            options={majorList}
            value={major}
            onChange={setMajor}
            getOptionLabel={option => option.majorName}
            getOptionValue={option => option.majorID}
          />
          <br />
          <label>Subject</label>
          <Select
            name="subjects"
            options={subjectList}
            value={subject}
            onChange={setSubject}
            onMenuOpen={fillSubjectDropdown}
            onMenuClose={emptySubjectList}
            getOptionLabel={option => option.subjectName}
            getOptionValue={option => option.subjectID}
          />
          <br />
          <button onClick={fillNoteList} className="btn btn-primary">
            List Notes
          </button>
        </div>
        <div className="container-fluid notelistdiv">
          <NoteList noteList={noteList} handleDownloadNote={downloadNote} />
        </div>
      </div>
    </div>
  );
}

export default App;
