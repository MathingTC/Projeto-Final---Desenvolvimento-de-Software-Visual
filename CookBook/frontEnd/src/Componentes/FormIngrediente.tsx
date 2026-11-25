import { useEffect, useState } from "react";
import axios from "axios";
import { Ingrediente } from "../Models/Ingrediente";

const url = "http://localhost:5093/api/ingredientes";

function FormIngrediente({ ingrediente, onSalvar, onCancelar }: {
    ingrediente: Ingrediente | null;
    onSalvar: () => void;
    onCancelar: () => void;
}) {
    const [nome, setNome] = useState("");
    const [erro, setErro] = useState("");

    // quando o usuário clica em "Editar", preenche o campo com o nome atual
    useEffect(() => {
        setNome(ingrediente ? ingrediente.nome : "");
        setErro("");
    }, [ingrediente]);

    function handleSubmit(e: any) {
        e.preventDefault();
        setErro("");

        const requisicao = ingrediente
            ? axios.put(`${url}/editar/${ingrediente.id}`, { nome }) // editar
            : axios.post(`${url}/cadastrar`, { nome }); // cadastrar

        requisicao
            .then(() => {
                setNome("");
                onSalvar();
            })
            .catch((erro) => {
                // se o backend respondeu, mostra a mensagem dele
                if (erro.response && typeof erro.response.data === "string") {
                    setErro(erro.response.data);
                } else {
                    setErro("Não foi possível salvar o ingrediente.");
                }
            });
    }

    return (
        <section>
            <h3>{ingrediente ? "Editar ingrediente" : "Cadastrar ingrediente"}</h3>

            <form onSubmit={handleSubmit}>
                <label>
                    Nome:
                    <input
                        type="text"
                        value={nome}
                        onChange={e => setNome(e.target.value)}
                        required
                    />
                </label>

                <button type="submit">
                    {ingrediente ? "Salvar alterações" : "Cadastrar"}
                </button>

                {ingrediente && (
                    <button type="button" onClick={onCancelar}>
                        Cancelar
                    </button>
                )}
            </form>

            {erro && <p className="erro">{erro}</p>}
        </section>
    );
}

export default FormIngrediente;