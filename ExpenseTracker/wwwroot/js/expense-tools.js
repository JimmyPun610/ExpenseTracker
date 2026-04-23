window.expenseStore = {
    get: (key) => localStorage.getItem(key),
    set: (key, value) => localStorage.setItem(key, value),
    remove: (key) => localStorage.removeItem(key)
};

window.csvTools = {
    download: (filename, csvContent) => {
        const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
        const url = URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = filename;
        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a);
        URL.revokeObjectURL(url);
    }
};

window.receiptOcr = {
    scan: async (streamRef, fileName) => {
        const arrayBuffer = await streamRef.arrayBuffer();
        const bytes = new Uint8Array(arrayBuffer);
        const blob = new Blob([bytes]);

        const dataUrl = await new Promise((resolve) => {
            const reader = new FileReader();
            reader.onload = () => resolve(reader.result);
            reader.readAsDataURL(blob);
        });

        let text = "";
        if (window.Tesseract?.recognize) {
            try {
                const result = await window.Tesseract.recognize(blob, "eng");
                text = result?.data?.text ?? "";
            } catch {
                text = "";
            }
        }

        const amount = parseAmount(text);
        const category = inferCategory(text);

        return {
            fileName,
            dataUrl,
            amount,
            category,
            text
        };
    }
};

function parseAmount(text) {
    if (!text) return null;
    const matches = text.match(/\d+[\.,]\d{2}/g);
    if (!matches?.length) return null;

    const values = matches
        .map((m) => Number.parseFloat(m.replace(",", ".")))
        .filter((n) => !Number.isNaN(n));

    if (!values.length) return null;
    return Math.max(...values);
}

function inferCategory(text) {
    if (!text) return null;
    const normalized = text.toLowerCase();

    if (/restaurant|cafe|food|supermarket|grocery/.test(normalized)) return "Food";
    if (/uber|taxi|bus|metro|fuel|petrol/.test(normalized)) return "Transport";
    if (/electric|water|utility|internet|bill/.test(normalized)) return "Bills";
    if (/pharmacy|clinic|hospital/.test(normalized)) return "Health";
    if (/cinema|movie|stream|game/.test(normalized)) return "Entertainment";

    return "Other";
}
