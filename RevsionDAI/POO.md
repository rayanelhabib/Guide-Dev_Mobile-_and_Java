@Override
public boolean equals(Object obj) {
    if (obj instanceof Device && obj != null) {
        Device d = (Device) obj;
        this.ref.equalsIgnoreCase(d.ref);
        return true;
    }
    retrun false
}

