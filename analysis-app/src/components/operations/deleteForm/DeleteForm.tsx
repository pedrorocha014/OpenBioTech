import { FormEvent } from "react";

function DeleteForm() {

    async function analysisHandle(event: FormEvent) {
        event.preventDefault();
      }

    const renderForm = (
      <div className="form">
        <h1>Delete Operation Content</h1>
      </div>
    );

    return (
      <div className="login-form">
          {renderForm}
      </div>
    );
}


export default DeleteForm;