import { useEffect, useState, useRef, SubmitEvent } from "react";
import { Ingrediente } from "../Models/Ingrediente";
import axios from "axios";

interface IngredientRow {
    key: number; // stable React key, so removing a row doesn't shuffle the others' state
    value: number | null; // null = nothing selected yet
    count: number | null;
    unit: string;
}

interface StepRow {
    desc: string;
    order: number;
}

function CadastrarEditarReceita() {
    const nextKey = useRef(1);

    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [ingredRows, setIngredRows] = useState<IngredientRow[]>([{ key: 0, value: null, count: null, unit: ''}]);
    const [ingreds, setIngreds] = useState<Ingrediente[]>([]);
    const [stepRows, setStepRows] = useState<StepRow[]>([{ order: 0, desc: '' }])
    const [carregando, setCarregando] = useState(true);

    useEffect(() => {
        axios.get<Ingrediente[]>(`http://localhost:5093/api/ingredientes/listar`)
        .then((resposta) => {
        setIngreds(resposta.data);
        })
        .catch((erro) => {
            console.error("Erro ao buscar a lista de ingredientes: ", erro);
        })
        .finally(() => {
            setCarregando(false);
        });
    }, []);

    const addIngredient = () => {
        setIngredRows((prev) => [...prev, { key: nextKey.current++, value: null, count: null, unit: '' }]);
    };

    const removeIngredient = (key: number) => {
        setIngredRows((prev) => prev.filter((row) => row.key !== key));
    };

    const updateIngredient = (key: number, value: number | null, count: number | null, unit: string) => {
        setIngredRows((prev) =>
            prev.map((row) => (row.key === key ? { ...row, value, count, unit } : row))
        );
    };

    const reorderSteps = (steps: StepRow[]) => {
        steps.sort((a,b) => a.order - b.order);
        steps.forEach((_, i) => {
            steps[i].order = i;
        });

        return steps;
    }

    const addStep = () => {
        setStepRows((prev) => {
            const newSteps = [...prev, { order: prev.length, desc: '' }]

            return reorderSteps(newSteps)
        });
    }

    const removeStep = (order: number) => {
        setStepRows((prev) => {
            const newSteps = prev.filter((s) => s.order !== order);

            return reorderSteps(newSteps);
        });
    }

    const updateStep = (order: number, desc: string) => {
        setStepRows((prev) => {
            return prev.map((row) => (row.order === order ? { ...row, desc } : row))
        });
    }

    const handleSubmit = (e: SubmitEvent<HTMLFormElement>) => {
        e.preventDefault();

        const recipe = {
          name,
          description,
          ingredients: ingredRows
            .map((row) => { return {
                ingredienteId: row.value,
                quantidade: row.count == 0 ? null : row.count,
                unidadeMedida: row.unit,
            };})
        };

        axios.post(
            `http://localhost:5093/api/receitas/cadastrar`,
            {
                nome: recipe.name,
                descricao: recipe.description,
                ingredientes: recipe.ingredients
            }
        );
    };

    return (
    <div>
    {carregando && <p>Carregando ingredientes...</p>}

    <form onSubmit={handleSubmit}>
      <h1>Submit a Recipe</h1>

      <div>
        <label htmlFor="name">Name</label>
        <input
          id="name"
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
          required
        />
      </div>

      <div>
        <label htmlFor="description">Description</label>
        <textarea
          id="description"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          required
        />
      </div>

      <fieldset>
        <legend>Ingredients</legend>

        {ingredRows.map((row, index) => (
          <div key={row.key}>
            <select
              aria-label={`Ingredient ${index + 1}`}
              value={row.value ?? ""}
              onChange={(e) =>
                updateIngredient(
                  row.key,
                  e.target.value === "" ? null : Number(e.target.value),
                  row.count,
                  row.unit
                )
              }
              required
            >
              <option value="" disabled>
                Select an ingredient
              </option>
              {ingreds.map((ing) => (
                <option key={ing.id} value={ing.id}>
                  {ing.nome}
                </option>
              ))}
            </select>

            <input
                type="number"
                value={row.count ?? ""}
                min={0}
                step="any"
                onChange={(e) => updateIngredient(
                    row.key,
                    row.value,
                    e.target.value === "" ? null : Number(e.target.value),
                    row.unit
                )}
            />

            <input
                type="text"
                value={row.unit}
                onChange={(e) => updateIngredient(
                    row.key,
                    row.value,
                    row.count,
                    e.target.value
                )}
            />

            <button
              type="button"
              onClick={() => removeIngredient(row.key)}
              aria-label={`Remove ingredient ${index + 1}`}
            >
              Remove
            </button>
          </div>
        ))}

        <button type="button" onClick={addIngredient}>
          Add ingredient

        </button>
      </fieldset>

      <fieldset>
        <legend>Etapas</legend>
        {stepRows.map((row, index) => (
          <div key={row.order}>
            <input
                type="text"
                value={row.desc}
                onChange={(e) => updateStep(
                    row.order,
                    e.target.value
                )}
            />

            <button
              type="button"
              onClick={() => removeStep(row.order)}
              aria-label={`Remove ingredient ${index + 1}`}
            >
              Remove
            </button>
          </div>
        ))}
        <button type="button" onClick={addStep}>
          Add ingredient

        </button>
      </fieldset>

      <button type="submit">Submit recipe</button>
    </form>
    </div>
    );
}

export default CadastrarEditarReceita;
