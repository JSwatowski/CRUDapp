import React, { useState } from 'react'


export default function PostCreateForm(props) {


    const initialFormData = Object.freeze({
        userName: "Enter your name",
        text: "Some text here."
    });

    const [formData, setFormData] = useState(initialFormData);
   

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };


    const handleSubmit = (e) => {
        e.preventDefault();

        const postToCreate = {
            postId: 0,
            userName: formData.userName,
            text: formData.text
        };
        const url = 'https://localhost:44334/api/Post/create';

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(postToCreate)
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error);

            });

        props.onPostCreated(postToCreate);
    };


    return (
      
            <form className="w-100 px-5">
                <h1 className="mt-5">Create new post</h1>

                <div className="mt-5">
                    <label className="h3 from-label">UserName</label>
                    <input value={formData.userName} name="userName" type="text" className="form-control" onChange={handleChange}></input>
                </div>

                <div className="mt-4">
                    <label className="h3 from-label">Post text</label>
                    <input value={formData.text} name="text" type="text" className="form-control" onChange={handleChange}></input>
                </div>
                
                <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
                <button onClick={() => props.onPostCreated(null)} className="btn btn-secondary btn-lg w-100 mt-3">Cancel</button>
               
            </form>
       
    );
}
