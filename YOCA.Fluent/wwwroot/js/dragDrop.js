// Simple drag and drop visual enhancements
window.initializeDragAndDrop = function () {
    let draggedTaskId = null;
    let isDragging = false;

    // Set the currently dragged task ID
    window.setDraggedTaskId = function (taskId) {
        draggedTaskId = taskId;
        isDragging = true;
        console.log('Setting dragged task ID:', taskId);
    };

    // Get the current dragged task ID
    window.getDraggedTaskId = function () {
        return draggedTaskId;
    };

    // Mark task as dragging for visual feedback
    window.markTaskAsDragging = function (taskId, dragging) {
        const taskElement = document.querySelector(`[data-task-id="${taskId}"]`);
        if (taskElement) {
            if (dragging) {
                taskElement.classList.add('dragging-task');
                taskElement.style.opacity = '0.5';
                taskElement.style.transform = 'rotate(2deg) scale(0.98)';
                taskElement.style.zIndex = '1000';
            } else {
                taskElement.classList.remove('dragging-task');
                taskElement.style.opacity = '';
                taskElement.style.transform = '';
                taskElement.style.zIndex = '';
            }
        }
    };

    // Clear all drag state and visual feedback
    window.clearDragState = function () {
        console.log('Clearing drag state');

        // Reset dragged task
        if (draggedTaskId) {
            markTaskAsDragging(draggedTaskId, false);
        }

        // Remove drop target styling from all boards
        const boards = document.querySelectorAll('.board-container');
        boards.forEach(board => {
            board.classList.remove('drop-target');
            board.style.border = '';
            board.style.background = '';
            board.style.transform = '';
            board.style.zIndex = '';
        });

        // Reset state
        draggedTaskId = null;
        isDragging = false;
    };

    // Add event listeners for drag operations
    function addDragListeners() {
        // Listen for dragstart on the document level
        document.addEventListener('dragstart', function (e) {
            const taskElement = e.target.closest('.task-card[data-task-id]');
            if (taskElement) {
                const taskId = taskElement.dataset.taskId;
                console.log('Drag started on task:', taskId);

                // Blazor will handle the main logic, just provide visual feedback here
                setTimeout(() => {
                    taskElement.classList.add('dragging-task');
                    taskElement.style.opacity = '0.5';
                }, 10);
            }
        });

        // Listen for dragend
        document.addEventListener('dragend', function (e) {
            console.log('Drag ended');
            const taskElement = e.target.closest('.task-card[data-task-id]');
            if (taskElement) {
                taskElement.classList.remove('dragging-task');
                taskElement.style.opacity = '';
                taskElement.style.transform = '';
                taskElement.style.zIndex = '';
            }

            // Clear drop targets
            const boards = document.querySelectorAll('.board-container');
            boards.forEach(board => {
                board.classList.remove('drop-target');
            });
        });

        // Listen for dragover on boards to provide visual feedback
        const boards = document.querySelectorAll('.board-container[data-board-id]');
        boards.forEach(board => {
            board.addEventListener('dragover', function (e) {
                e.preventDefault(); // Allow drop

                if (isDragging && draggedTaskId) {
                    // Remove previous drop target styling
                    document.querySelectorAll('.board-container.drop-target').forEach(b => {
                        b.classList.remove('drop-target');
                    });

                    // Add to current board
                    this.classList.add('drop-target');
                }
            });

            board.addEventListener('dragleave', function (e) {
                // Only remove if leaving the actual board element
                if (e.target === this || e.target.closest('.board-container') === this) {
                    this.classList.remove('drop-target');
                }
            });

            board.addEventListener('drop', function (e) {
                e.preventDefault();
                console.log('Drop on board:', this.dataset.boardId);

                // Blazor handles the actual drop logic
                this.classList.remove('drop-target');
            });
        });
    }

    // Initialize listeners
    setTimeout(addDragListeners, 100); // Small delay to ensure DOM is ready

    // Re-attach listeners when Blazor re-renders components
    const observer = new MutationObserver(function (mutations) {
        let shouldReattach = false;
        mutations.forEach(function (mutation) {
            if (mutation.type === 'childList' &&
                (mutation.addedNodes.length > 0 || mutation.removedNodes.length > 0)) {
                shouldReattach = true;
            }
        });

        if (shouldReattach) {
            setTimeout(addDragListeners, 50);
        }
    });

    // Observe changes in the main app container
    const appContainer = document.getElementById('app') || document.body;
    observer.observe(appContainer, {
        childList: true,
        subtree: true
    });

    console.log('Drag and drop visual system initialized');
};

// Fallback if Blazor initialization fails
if (typeof window.blazorReady === 'undefined') {
    window.blazorReady = true; // Mark as ready
}