from flask import Flask, request, jsonify
from transformers import AutoTokenizer, AutoModelForSeq2SeqLM
import fitz  
import os
import json

app = Flask(__name__)

"""
model_name = r"E:\BIG\MODEL\flan-t5-base"
tokenizer = AutoTokenizer.from_pretrained(model_name)
model = AutoModelForSeq2SeqLM.from_pretrained(model_name)
"""

MODEL_PATH = os.path.join(os.path.dirname(__file__), "models", "flan-t5-base")
tokenizer = AutoTokenizer.from_pretrained("google/flan-t5-base", cache_dir=MODEL_PATH)
model = AutoModelForSeq2SeqLM.from_pretrained("google/flan-t5-base", cache_dir=MODEL_PATH)


@app.route('/extract', methods=['POST'])
def extract_info():
    try:
        # Accept comma-separated or JSON-style instruction list
        raw_instructions = request.form.get('instruction', '').strip()
        file = request.files.get('file')

        if not raw_instructions:
            return jsonify({"error": "Instruction(s) are missing"}), 400
        if not file:
            return jsonify({"error": "File is missing"}), 400

        # Parse the instruction(s)
        try:
            if raw_instructions.startswith("["):
                instructions = json.loads(raw_instructions)
            else:
                instructions = [instr.strip() for instr in raw_instructions.split(",") if instr.strip()]
        except Exception as e:
            return jsonify({"error": f"Invalid instruction format: {str(e)}"}), 400

        if not instructions:
            return jsonify({"error": "No valid instructions found"}), 400

        # Save and extract text from PDF
        temp_path = "temp.pdf"
        file.save(temp_path)

        doc = fitz.open(temp_path)
        text = "".join([page.get_text() for page in doc])
        doc.close()
        os.remove(temp_path)

        if not text.strip():
            return jsonify({"error": "No text found in PDF"}), 400

      

        def format_label(instruction):
            instruction = instruction.lower().replace("extract", "").replace("_", " ").replace("-", " ").strip()
            return " ".join(word.capitalize() for word in instruction.split())

        # Process each instruction
        results = {}
        for instruction in instructions:
            prompt = f"Extract only the {instruction.lower()} from the following text:\n\n{text}\n\nAnswer:"
            inputs = tokenizer(prompt, return_tensors="pt", max_length=512, truncation=True)
            output = model.generate(**inputs, max_new_tokens=100)
            result = tokenizer.decode(output[0], skip_special_tokens=True)

            label = format_label(instruction)
            results[label] = result.strip()

        return jsonify({"extracted_results": results})

    except Exception as e:
        print("ERROR:", str(e))
        return jsonify({"error": str(e)}), 500

if __name__ == '__main__':
    print("Server is running...")
    app.run(host='127.0.0.1', port=5000, debug=True)
