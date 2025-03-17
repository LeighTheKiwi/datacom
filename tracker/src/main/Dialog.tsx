import { useEffect, useRef } from "react";
import "./Dialog.scss";

type Args = {
    title: string;
    children: React.ReactNode;
    close: () => void;
};

const Dialog = ({ title, children, close }: Args) => {

    const _dialog = useRef<HTMLDialogElement | null>(null);

    useEffect(() => {

        if(_dialog) {
            _dialog?.current?.showModal();
        }
    }, []);

    return (
        <dialog ref={_dialog} id="modalDialog" className='t-dialog modal'>
            <div className="t-dialog-header">
                <span>{ title }</span>
                <span className="t-option" title="close" onClick={close}>X</span>
            </div>
            <div className="t-dialog-content">
                {children}
            </div>
        </dialog>
    )
}

export default Dialog;