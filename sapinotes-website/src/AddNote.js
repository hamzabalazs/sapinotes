import React, { useEffect, useState } from 'react';
import Header from './Header'
import {useNavigate} from 'react-router-dom'

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

    const navigate = useNavigate();
    useEffect(() => {
    if(!localStorage.getItem('user-info')){
        navigate('/login');
    }
    })

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
                <label>Note Name</label>
                <input type="text" placeholder="note name" onChange={(e) => setNoteName(e.target.value)} className="form-control"/>
                <br/>
                <label>File</label>
                <input type="file" onChange={(e) => setSelectedFile(e.target.value)} className="form-control"/>
                <br/>
                <button onClick={Add} className="btn btn-primary">Login</button>
            </div>
        </div>
        </div>
    );
}

export default AddNote;