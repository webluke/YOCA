window.tuiEditors = {};

function createEditor(
    elementId,
    dotNetHelper,
    initialValue,
    placeholder
) {
    const container = document.getElementById(elementId);
    if (!container) {
        console.error(`Element with id ${elementId} not found.`);
        return;
    }
    container.innerHTML = "";

    const { codeSyntaxHighlight } = toastui.Editor.plugin;

    const editor = new toastui.Editor({
        el: container,
        height: "500px",
        initialEditType: "wysiwyg",
        previewStyle: "tab",
        initialValue: initialValue || "",
        placeholder: placeholder || "Write something awesome...",
        theme: "dark",
        plugins: [[codeSyntaxHighlight, { highlighter: Prism }]],
        events: {
            change: () => {
                const markdown = editor.getMarkdown();
                dotNetHelper.invokeMethodAsync("OnMarkdownChanged", markdown);
            },
        },
    });

    window.tuiEditors[elementId] = editor;
}

function getMarkdown(elementId) {
    if (window.tuiEditors[elementId]) {
        return window.tuiEditors[elementId].getMarkdown();
    }
    return "";
}

function setMarkdown(elementId, markdown) {
    if (window.tuiEditors[elementId]) {
        window.tuiEditors[elementId].setMarkdown(markdown, false);
    }
}

function destroyEditor(elementId) {
    const editor = window.tuiEditors[elementId];
    if (editor) {
        try {
            editor.destroy();
        } catch (e) {
            console.warn(`Failed to destroy editor ${elementId}`, e);
        }
        delete window.tuiEditors[elementId];
    }

    const container = document.getElementById(elementId);
    if (container) {
        container.innerHTML = "";
    }
}

window.highlightCode = () => {
    Prism.highlightAll();
};
