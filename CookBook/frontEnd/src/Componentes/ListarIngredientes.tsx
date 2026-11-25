import { useEffect, useState } from "react";
import { Ingrediente } from "../Models/Ingrediente";

const url = "http://localhost:5093/api/ingredientes";

function ListarIngredientes({ onEditar }: {
    onEditar: (ingrediente: Ingrediente) => void;
}) {
    const [ingredientes, setIngredientes] = useState<Ingrediente[]>([]);
    const [carregando, setCarregando] = useState(true);
    const [erro, setErro] = useState("");

    useEffect(() => {
        fetch(`${url}/listar`)
            .then(resposta => {
                if (!resposta.ok) {
                    throw new Error("Erro na requisição: " + resposta.statusText);
                }
                return resposta.json();
            })
            .then(dados => {
                // a lista vazia pode vir como texto
                setIngredientes(Array.isArray(dados) ? dados : []);
            })
            .catch(() => {
                setErro("Não foi possível carregar os ingredientes.");
            })
            .finally(() => {
                setCarregando(false);
            });
    }, []);

    function remover(ingrediente: Ingrediente) {
        if (!window.confirm(`Remover ingrediente "${ingrediente.nome}"?`)) {
            return;
        }
        setErro("");

        fetch(`${url}/remover/${ingrediente.id}`, { method: "DELETE" })
            .then(async resposta => {
                if (!resposta.ok) {
                    const mensagem = await resposta.json();
                    setErro(typeof mensagem === "string" ? mensagem : mensagem.erro);
                    return;
                }
                setIngredientes(ingredientes.filter(i => i.id !== ingrediente.id));
            })
            .catch(() => {
                setErro("Não foi possível remover o ingrediente.");
            });
    }

    return (
        <section>
            <h2>Ingredientes</h2>

            {carregando && <p>Carregando ingredientes...</p>}
            {erro && <p className="erro">{erro}</p>}

            {!carregando && ingredientes.length === 0 && (
                <p>Nenhum ingrediente cadastrado!</p>
            )}

            <div className="lista-ingredientes">
                {ingredientes.map(ingrediente => (
                    <div key={ingrediente.id} className="item-ingrediente">
                        <span>{ingrediente.nome}</span>
                        <div>
                            <button onClick={() => onEditar(ingrediente)}>Editar</button>
                            <button onClick={() => remover(ingrediente)}>Remover</button>
                        </div>
                    </div>
                ))}
            </div>
        </section>
    );
}

export default ListarIngredientes;
