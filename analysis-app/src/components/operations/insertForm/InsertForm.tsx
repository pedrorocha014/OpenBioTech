import { FormEvent } from "react";

function InsertForm() {

    async function analysisHandle(event: FormEvent) {
        event.preventDefault();
      }

    const renderForm = (
      <div className="form">
        <h1>Insert Operation Content</h1>
      </div>
    );

    return (
      <div className="login-form">
          {renderForm}
      </div>
    );
}


export default InsertForm;