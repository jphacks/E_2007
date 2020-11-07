import os

import torch
from transformers import AutoTokenizer, AutoModelForSequenceClassification, AdapterType


class SA:
    def __init__(self):
        adapter_path = os.path.join(os.path.dirname(
            os.path.abspath(__file__)), "sst-2")
        self.model = AutoModelForSequenceClassification.from_pretrained(
            "cl-tohoku/bert-base-japanese-whole-word-masking")
        self.tokenizer = AutoTokenizer.from_pretrained(
            "cl-tohoku/bert-base-japanese-whole-word-masking")
        self.model.load_adapter(adapter_path)

    def detect_p_or_n(self, txt: str) -> "positive" or "negative":
        token_ids = self.tokenizer.convert_tokens_to_ids(
            self.tokenizer.tokenize(txt))
        input_tensor = torch.tensor([token_ids])
        outputs = self.model(input_tensor, adapter_names=["sst-2"])
        result = torch.argmax(outputs[0]).item()

        return 'positive' if result == 1 else 'negative'
