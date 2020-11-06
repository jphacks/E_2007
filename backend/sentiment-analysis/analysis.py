import os

import torch
from transformers import AutoTokenizer, AutoModelForSequenceClassification, AdapterType


def get_analyzer():
    adapter_path = os.path.join(os.path.dirname(
        os.path.abspath(__file__)), "sst-2")
    model = AutoModelForSequenceClassification.from_pretrained(
        "cl-tohoku/bert-base-japanese-whole-word-masking")
    tokenizer = AutoTokenizer.from_pretrained(
        "cl-tohoku/bert-base-japanese-whole-word-masking")
    model.load_adapter(adapter_path)

    def analyzer(sentence: str) -> "positive" or "negative":
        token_ids = tokenizer.convert_tokens_to_ids(
            tokenizer.tokenize(sentence))
        input_tensor = torch.tensor([token_ids])
        outputs = model(input_tensor, adapter_names=["sst-2"])
        result = torch.argmax(outputs[0]).item()

        return 'positive' if result == 1 else 'negative'

    return analyzer
