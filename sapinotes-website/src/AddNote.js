import React, { useEffect, useState } from 'react';
import Header from './Header'
import {useNavigate} from 'react-router-dom'
import Select from "react-select";

async function PostNote(userID,subjectID, noteName, noteDocID) {
    let url = "https://localhost:7214/api/Notes/add-new-note";
    let item = {userID,subjectID,noteName,noteDocID}
    return fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(item)
      
    })
      .then(data => data.json())
}



function AddNote(){

    const [selectedFile,setSelectedFile] = useState();
    const [noteName, setNoteName] = useState();
    const [subject, setSubject] = useState();
    const [major, setMajor] = useState();
    const [subjectList, setSubjectList] = useState([]);
    const [majorList, setMajorList] = useState([]);
    

    const getMajorList = async () => {
        let url = "https://localhost:7214/api/Majors/getmajors";
        fetch(url).then(response => response.json()).then(output => {setMajorList([...majorList, ...output])});
    };

    const getSubjectList = async (majorId) => {
        let url = "https://localhost:7214/api/Subjects/get-subjects-of-major?majorId=" + majorId;
        fetch(url).then(response => response.json()).then(output => {setSubjectList([...subjectList, ...output])});
    }

    const fillSubjectDropdown = () => {
        
        setSubjectList([])
        let id = major.majorID;
        getSubjectList(id);
        console.log(subjectList);
    }


    const navigate = useNavigate();
    useEffect(() => {
        getMajorList();
        
        if(!localStorage.getItem('user-info')){
            navigate('/login');
        }
    }, [])

    const Add = async e => {

        e.preventDefault();
        let user = JSON.parse(localStorage.getItem('user-info'));
        const userid = user.userID;
    }

  

    return(
        <div>
        <Header/>
        <div className='bodydiv-with-nav'>
            <h1>Add a new note</h1>
            <div className="col-sm-6 offset-sm-3">
                <label>Major</label>
                <Select
                    name="majors"
                    options={majorList}
                    value={major}
                    onChange={setMajor}
                    getOptionLabel={(option) => option.majorName}
                    getOptionValue={(option) => option.majorID}
                />
                <br/>
                <label>Subject</label>
                <Select
                    name="subjects"
                    options={subjectList}
                    value={subject}
                    onChange={setSubject}
                    onMenuOpen={fillSubjectDropdown}
                    getOptionLabel={(option) => option.subjectName}
                    getOptionValue={(option) => option.subjectID}
                />
                <br/>
                <label>Note Name</label>
                <input type="text" placeholder="note name" onChange={(e) => setNoteName(e.target.value)} className="form-control"/>
                <br/>
                <label>File</label>
                <input type="file" onChange={(e) => setSelectedFile(e.target.value)} className="form-control"/>
                <br/>
                <button onClick={Add} className="btn btn-primary">Add Note</button>
            </div>
        </div>
        </div>
    );
}

export default AddNote;